import { Decorators, Widget, WidgetProps, serviceRequest, notifySuccess, notifyError, getLookupAsync, resolveUrl } from '@serenity-is/corelib';
import { AssetsRow, AssetsService, AssetStatus } from '../../ServerTypes/Operations';
import { AssetsDialog } from './AssetsDialog';
import Sortable from 'sortablejs';

@Decorators.registerClass('HRMS.Operations.AssetKanbanBoard')
export class AssetKanbanBoard extends Widget<any> {

    private assets: AssetsRow[] = [];

    constructor(props: WidgetProps<any>) {
        super(props);
        this.loadAssets();
    }

    private loadAssets() {
        serviceRequest(AssetsService.Methods.List, {}, (response: any) => {
            this.assets = response.Entities || [];
            this.renderBoard();
        });
    }

    private renderBoard() {
        const el = this.domNode;
        el.innerHTML = '';
        this.addStyles(el);

        const container = document.createElement('div');
        container.id = 'kanban-container';

        // Header
        const header = document.createElement('div');
        header.className = 'kanban-header';
        header.innerHTML = `
            <h2><i class="fa fa-th-large"></i> Asset Management</h2>
            <button id="refresh-kanban" class="btn btn-default"><i class="fa fa-refresh"></i> Refresh</button>
        `;
        container.appendChild(header);

        // Board
        const board = document.createElement('div');
        board.className = 'kanban-board';

        const columns = [
            { id: 1, name: 'Available', class: 'available', icon: '✅' },
            { id: 2, name: 'In Use', class: 'in-use', icon: '👤' },
            { id: 3, name: 'In Repair', class: 'in-repair', icon: '🔧' },
            { id: 4, name: 'Retired', class: 'retired', icon: '🗑️' }
        ];

        columns.forEach(col => {
            const colDiv = document.createElement('div');
            colDiv.className = 'kanban-column';
            colDiv.setAttribute('data-status', col.id.toString());

            const items = this.assets.filter(x => (x.Status || 1) === col.id);

            colDiv.innerHTML = `
                <div class="column-header ${col.class}">
                    <h3>${col.icon} ${col.name}</h3>
                    <span class="count">${items.length}</span>
                </div>
                <div class="column-content sortable" id="column-${col.id}"></div>
            `;

            const contentDiv = colDiv.querySelector('.column-content') as HTMLElement;
            items.forEach(asset => {
                const card = this.createAssetCard(asset);
                contentDiv.appendChild(card);
            });

            // Empty state
            if (items.length === 0) {
                const empty = document.createElement('div');
                empty.className = 'empty-state';
                empty.textContent = 'No assets';
                contentDiv.appendChild(empty);
            }

            // Sortable
            new Sortable(contentDiv, {
                group: 'kanban',
                animation: 150,
                ghostClass: 'dragging',
                onEnd: (evt: any) => this.handleDrop(evt)
            });

            board.appendChild(colDiv);
        });

        container.appendChild(board);
        el.appendChild(container);

        // Events
        const refreshBtn = header.querySelector('#refresh-kanban');
        if (refreshBtn) {
            refreshBtn.addEventListener('click', () => this.loadAssets());
        }
    }

    private createAssetCard(asset: AssetsRow) {
        const card = document.createElement('div');
        card.className = 'asset-card';
        card.setAttribute('data-id', asset.AssetId.toString());

        const assignedInfo = asset.AssignedToFullName
            ? `<div class="asset-info"><i class="fa fa-user"></i> ${asset.AssignedToFullName}</div>`
            : `<div class="asset-info"><i class="fa fa-user-times"></i> Unassigned</div>`;

        card.innerHTML = `
            <div class="asset-name">${asset.AssetName}</div>
            ${asset.SerialNumber ? `<div class="asset-info"><i class="fa fa-barcode"></i> ${asset.SerialNumber}</div>` : ''}
            ${assignedInfo}
            <div class="asset-info"><i class="fa fa-money"></i> ${asset.Cost || '-'}</div>
        `;

        // Click to edit - redirect to existing Assets page
        card.addEventListener('click', (e) => {
            window.location.href = resolveUrl(`~/Operations/Assets#edit/${asset.AssetId}`);
        });

        return card;
    }

    private handleDrop(evt: any) {
        const assetId = parseInt(evt.item.getAttribute('data-id'), 10);
        const newStatus = parseInt(evt.to.parentElement.getAttribute('data-status'), 10);
        const oldStatus = parseInt(evt.from.parentElement.getAttribute('data-status'), 10);

        if (evt.from !== evt.to) {
            // Moved to In Use (2)
            if (newStatus === 2) {
                this.askWhoToAssign((assignedTo) => {
                    this.updateStatus(assetId, newStatus, assignedTo);
                }, () => {
                    this.loadAssets(); // Revert
                });
                return;
            }

            this.updateStatus(assetId, newStatus);
        }
    }

    private updateStatus(assetId: number, status: number, assignedTo?: number) {
        serviceRequest('Operations/Assets/UpdateStatus', {
            AssetId: assetId,
            NewStatus: status,
            AssignedTo: assignedTo
        }, () => {
            notifySuccess('Asset status updated successfully!');
            this.loadAssets();
        }, {
            onError: (response: any) => {
                notifyError(response.Error?.Message || 'Failed to update status');
                this.loadAssets();
            }
        });
    }

    private askWhoToAssign(onConfirm: (id: number) => void, onCancel: () => void) {
        getLookupAsync('HR.Employee').then(lookup => {
            const items = lookup.items || [];

            const overlay = document.createElement('div');
            overlay.className = 'assign-overlay';

            overlay.innerHTML = `
                <div class="assign-modal">
                    <h4>Who to assign?</h4>
                    <p>Select employee for this asset before moving to In Use.</p>
                    <select id="assign-select">
                        <option value="">Select employee</option>
                        ${items.map((i: any) => `<option value="${i.EmployeeId || i.id}">${i.FullName || i.text}</option>`).join('')}
                    </select>
                    <div class="assign-actions">
                        <button type="button" class="btn btn-default" id="assign-cancel">Cancel</button>
                        <button type="button" class="btn btn-primary" id="assign-confirm">Assign</button>
                    </div>
                </div>
            `;
            document.body.appendChild(overlay);

            const close = () => { document.body.removeChild(overlay); };

            overlay.querySelector('#assign-cancel').addEventListener('click', () => {
                close();
                onCancel();
            });

            overlay.querySelector('#assign-confirm').addEventListener('click', () => {
                const select = overlay.querySelector('#assign-select') as HTMLSelectElement;
                if (!select.value) {
                    notifyError('Please select who to assign.');
                    return;
                }
                close();
                onConfirm(parseInt(select.value, 10));
            });
        }).catch(() => {
            notifyError('Unable to load employee list.');
            onCancel();
        });
    }

    private addStyles(el: HTMLElement) {
        const style = document.createElement('style');
        style.textContent = `
            #kanban-container { padding: 20px; background: #f5f5f5; min-height: calc(100vh - 100px); }
            .kanban-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px; padding: 15px 20px; background: white; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }
            .kanban-header h2 { margin: 0; color: #333; }
            .kanban-board { display: grid; grid-template-columns: repeat(4, 1fr); gap: 15px; overflow-x: auto; }
            .kanban-column { min-width: 250px; background: white; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); display: flex; flex-direction: column; max-height: calc(100vh - 180px); }
            .column-header { padding: 15px; border-radius: 8px 8px 0 0; color: white; display: flex; justify-content: space-between; align-items: center; }
            .column-header h3 { margin: 0; font-size: 16px; font-weight: 600; }
            .column-header .count { background: rgba(255,255,255,0.3); padding: 4px 12px; border-radius: 12px; font-weight: bold; }
            .column-header.available { background: #27ae60; }
            .column-header.in-use { background: #3498db; }
            .column-header.in-repair { background: #e67e22; }
            .column-header.retired { background: #7f8c8d; }
            .column-content { flex: 1; overflow-y: auto; padding: 10px; min-height: 200px; }
            .asset-card { background: #fff; border: 2px solid #e0e0e0; border-radius: 6px; padding: 12px; margin-bottom: 10px; cursor: move; transition: all 0.3s; box-shadow: 0 1px 3px rgba(0,0,0,0.1); }
            .asset-card:hover { box-shadow: 0 4px 12px rgba(0,0,0,0.15); transform: translateY(-2px); border-color: #3498db; }
            .asset-card.dragging { opacity: 0.5; }
            .asset-name { font-weight: bold; font-size: 15px; color: #2c3e50; margin-bottom: 8px; }
            .asset-info { font-size: 13px; color: #7f8c8d; margin-bottom: 4px; display: flex; align-items: center; gap: 6px; }
            .asset-info i { width: 16px; }
            .empty-state { text-align: center; padding: 40px 20px; color: #bdc3c7; font-style: italic; }
            .assign-overlay { position: fixed; inset: 0; background: rgba(0, 0, 0, 0.45); display: flex; align-items: center; justify-content: center; z-index: 2000; }
            .assign-modal { width: min(92vw, 420px); background: #fff; border-radius: 10px; box-shadow: 0 10px 30px rgba(0, 0, 0, 0.25); padding: 18px; }
            .assign-modal h4 { margin: 0 0 12px; font-size: 18px; color: #2c3e50; }
            .assign-modal p { margin: 0 0 10px; color: #5d6d7e; font-size: 13px; }
            .assign-modal select { width: 100%; height: 36px; border: 1px solid #d0d7de; border-radius: 6px; padding: 4px 8px; }
            .assign-actions { margin-top: 14px; display: flex; justify-content: flex-end; gap: 8px; }
            .assign-actions .btn { min-width: 88px; }
            @media (max-width: 1000px) { .kanban-board { grid-template-columns: repeat(2, 1fr); } }
            @media (max-width: 600px) { .kanban-board { grid-template-columns: 1fr; } }
        `;
        el.appendChild(style);
    }
}

export default () => {
    const container = document.getElementById('GridDiv');
    if (container) {
        new AssetKanbanBoard({ element: container });
    }
};
