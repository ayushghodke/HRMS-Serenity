import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { EmployeeDocsColumns, EmployeeDocsRow, EmployeeDocsService } from '../../ServerTypes/HR';
import { EmployeeDocsDialog } from './EmployeeDocsDialog';

@Decorators.registerClass('HRMS.HR.EmployeeDocsGrid')
export class EmployeeDocsGrid extends EntityGrid<EmployeeDocsRow, any> {
    protected getColumnsKey() { return EmployeeDocsColumns.columnsKey; }
    protected getDialogType() { return EmployeeDocsDialog; }
    protected getRowDefinition() { return EmployeeDocsRow; }
    protected getService() { return EmployeeDocsService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }

    protected override getButtons() {
        var buttons = super.getButtons();
        buttons.push({
            title: 'Refresh',
            cssClass: 'refresh-button',
            onClick: () => this.refresh()
        });
        return buttons;
    }

    private _employeeId: number;

    get employeeId() {
        return this._employeeId;
    }

    set employeeId(value: number) {
        if (this._employeeId !== value) {
            this._employeeId = value;
            this.setEquality('EmployeeId', value);
            this.refresh();
        }
    }

    protected override initEntityDialog(itemType: string, dialog: Serenity.Widget<any>) {
        super.initEntityDialog(itemType, dialog);
        (dialog as any).employeeId = this.employeeId;
    }

    protected override getGridCanLoad() {
        return super.getGridCanLoad() && !!this.employeeId;
    }

    protected override getAddButtonCaption() {
        return "Add Document";
    }

    protected override onClick(e: JQuery.Event, row: number, cell: number) {
        super.onClick(e, row, cell);
    }
}
