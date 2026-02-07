import { Decorators, EntityGrid, GridRowSelectionMixin } from '@serenity-is/corelib';

@Decorators.registerClass('HRMS.Common.GridEditorBase')
export class GridEditorBase<TEntity> extends EntityGrid<TEntity, any> {
    protected getID(item: TEntity) {
        if ((item as any).__id)
            return (item as any).__id;
        return super.getID(item);
    }

    protected getDisplayName() { return ""; }
    protected getLocalTextPrefix() { return ""; }
    protected getService() { return ""; }

    constructor(container: JQuery) {
        super(container);
    }

    protected onViewSubmit() {
        return false;
    }

    protected getButtons() {
        var buttons = super.getButtons();
        buttons.push({
            title: "Add " + this.getDisplayName(),
            cssClass: "add-button",
            onClick: () => {
                this.createEntityDialog(this.getItemType(), dlg => {
                    var dialog = dlg as GridEditorDialog<TEntity>;
                    dialog.onSave = (opt, callback) => this.save(opt, callback);
                    dialog.loadEntityAndOpenDialog({});
                });
            }
        });
        return buttons;
    }

    protected editItem(entityOrId: any) {
        var id = entityOrId;
        var item = this.view.getItemById(id);
        this.createEntityDialog(this.getItemType(), dlg => {
            var dialog = dlg as GridEditorDialog<TEntity>;
            dialog.onSave = (opt, callback) => this.save(opt, callback);
            dialog.loadEntityAndOpenDialog(item);
        });
    }

    protected getEditValue(property, target) {
        target[property] = this.value;
    }

    protected getGridCanLoad() {
        return false;
    }

    protected usePager() {
        return false;
    }

    protected getInitialTitle() {
        return null;
    }

    private nextId = 1;

    protected save(opt: any, callback: (r: any) => void) {
        var request = opt.request;
        var row = Q.deepClone(request.Entity);
        var id = this.getID(row);
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
            var index = items.findIndex(x => this.getID(x) == id);
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
        this.resetCheckedAndRefresh();
    }

    protected getNewEntity(): TEntity {
        return {} as TEntity;
    }

    protected getButtons() {
        return [{
            title: 'Add',
            cssClass: 'add-button',
            onClick: () => {
                this.createEntityDialog(this.getItemType(), dlg => {
                    var dialog = dlg as GridEditorDialog<TEntity>;
                    dialog.onSave = (opt, callback) => this.save(opt, callback);
                    dialog.loadEntityAndOpenDialog(this.getNewEntity());
                });
            }
        }];
    }

    public get value(): TEntity[] {
        return this.view.getItems().map(x => {
            var y = Q.deepClone(x);
            delete y['__id'];
            return y;
        });
    }

    public set value(value: TEntity[]) {
        var p = this.getIDProperty();
        this.view.setItems((value || []).map(x => {
            var y = Q.deepClone(x);
            if ((y as any)[p] == null)
                (y as any)[p] = (y as any).__id = this.nextId++;
            return y;
        }), true);
    }

    protected getGridCanLoad() { return false; }
    protected usePager() { return false; }
    protected getInitialTitle() { return null; }
    protected createQuickSearchInput() { }
}
