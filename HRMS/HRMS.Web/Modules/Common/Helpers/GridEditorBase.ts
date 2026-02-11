import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { GridEditorDialog } from './GridEditorDialog';

@Decorators.registerClass('HRMS.Common.GridEditorBase')
export class GridEditorBase<TEntity> extends EntityGrid<TEntity, any> {
    protected getId(item: TEntity) {
        if ((item as any).__id)
            return (item as any).__id;
        return (item as any)[this.getIdProperty()];
    }

    protected getIdProperty() {
        return this.getRowDefinition().idProperty;
    }

    protected override getDisplayName() { return ""; }
    protected override getLocalTextPrefix() { return ""; }
    protected override getService() { return ""; }

    constructor(container: any) {
        super(container);
    }

    protected override getButtons() {
        return [{
            title: 'Add ' + this.getDisplayName(),
            cssClass: 'add-button',
            onClick: () => {
                this.createEntityDialog(this.getItemType(), dlg => {
                    var dialog = dlg as GridEditorDialog<TEntity>;
                    dialog.onSave = (options, callback) => this.save(options, callback);
                    dialog.loadEntityAndOpenDialog(this.getNewEntity());
                });
            }
        }];
    }

    protected override createEntityDialog(itemType: string, callback: (dlg: any) => void) {
        var dlg = super.createEntityDialog(itemType, callback);
        if (!dlg) return dlg;
        return dlg;
    }

    protected override editItem(entityOrId: any): void {
        var id = entityOrId;
        var item = this.view.getItemById(id);

        this.createEntityDialog(this.getItemType(), dlg => {
            var dialog = dlg as GridEditorDialog<TEntity>;
            dialog.onSave = (options, callback) => this.save(options, callback);
            dialog.loadEntityAndOpenDialog(item);
        });
    }

    protected save(opt: any, callback: (r: any) => void) {
        var request = opt.request;
        var row = JSON.parse(JSON.stringify(request.Entity));
        var id = this.getId(row);
        if (id == null) {
            row.__id = this.nextId++;
        }

        if (!this.validateEntity(row, id)) {
            return;
        }

        var items = this.view.getItems().slice();
        if (id == null) {
            items.push(row);
        } else {
            var index = items.findIndex(x => this.getId(x) == id);
            if (index >= 0) {
                items[index] = row;
            }
        }

        this.setEntities(items);
        callback({});
    }

    protected validateEntity(row: TEntity, id: any) {
        return true;
    }

    protected setEntities(items: TEntity[]) {
        this.view.setItems(items, true);
    }

    protected getNewEntity(): TEntity {
        return {} as TEntity;
    }

    protected override getGridCanLoad() { return false; }
    protected override usePager() { return false; }
    protected override getInitialTitle() { return null; }
    protected override createQuickSearchInput() { }

    private nextId = 1;

    public get value(): TEntity[] {
        return this.view.getItems().map(x => {
            var y = JSON.parse(JSON.stringify(x));
            delete y['__id'];
            return y;
        });
    }

    public set value(value: TEntity[]) {
        var p = this.getIdProperty();
        this.view.setItems((value || []).map(x => {
            var y = JSON.parse(JSON.stringify(x));
            if ((y as any)[p] == null)
                (y as any)[p] = (y as any).__id = this.nextId++;
            return y;
        }), true);
    }
}
