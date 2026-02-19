import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { SocialPostMediaColumns, SocialPostMediaRow } from '../../ServerTypes/Communication';
import { SocialPostMediaEditDialog } from './SocialPostMediaEditDialog';

@Decorators.registerClass('HRMS.Communication.SocialPostMediaEditor')
export class SocialPostMediaEditor extends EntityGrid<SocialPostMediaRow, any> {
    protected override getColumnsKey() { return SocialPostMediaColumns.columnsKey; }
    protected override getDialogType() { return SocialPostMediaEditDialog; }
    protected override getRowDefinition() { return SocialPostMediaRow; }

    constructor(props: any) {
        super(props);
    }

    protected override getIdProperty() { return '__id'; }

    protected override getService(): string {
        return null as any;
    }

    private nextId = 1;

    protected override getButtons() {
        var buttons = super.getButtons();
        buttons.splice(buttons.findIndex(x => x.cssClass?.indexOf('column-picker-button') >= 0), 1);
        return buttons;
    }

    protected override onClick(e: any, row: number, cell: number) {
        super.onClick(e, row, cell);
    }

    public setItems(items: SocialPostMediaRow[]) {
        this.view.setItems(items.map((item, i) => {
            (item as any).__id = (item as any).__id ?? ('_' + (i + 1));
            return item;
        }), true);
    }

    public getEditValue() {
        return this.view.getItems().map(item => {
            const clone = { ...item } as any;
            delete clone.__id;
            return clone;
        });
    }

    public setEditValue(value: any) {
        this.setItems(value || []);
    }
}
