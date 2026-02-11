import { Decorators, EntityGrid, isEmptyOrNull } from '@serenity-is/corelib';
import { EmployeeSalaryDetailsColumns, EmployeeSalaryDetailsRow, EmployeeSalaryDetailsService, EmployeeSalaryDetailsForm } from '../../ServerTypes/HR';
import { SalaryComponentsRow } from '../../ServerTypes/Operations';
import { GridEditorBase } from '../../Common/Helpers/GridEditorBase';
import { GridEditorDialog } from '../../Common/Helpers/GridEditorDialog';

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDetailsEditor')
export class EmployeeSalaryDetailsEditor extends GridEditorBase<EmployeeSalaryDetailsRow> {
    protected override getColumnsKey() { return EmployeeSalaryDetailsColumns.columnsKey; }
    protected override getLocalTextPrefix() { return EmployeeSalaryDetailsRow.localTextPrefix; }
    protected override getRowDefinition() { return EmployeeSalaryDetailsRow; }
    protected override getDialogType() { return EmployeeSalaryDetailsEditDialog; }

    constructor(container: HTMLElement) {
        super(container);
    }
}

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDetailsEditDialog')
export class EmployeeSalaryDetailsEditDialog extends GridEditorDialog<EmployeeSalaryDetailsRow> {
    protected override getFormKey() { return 'HR.EmployeeSalaryDetails'; }
    protected override getLocalTextPrefix() { return EmployeeSalaryDetailsRow.localTextPrefix; }

    protected form: EmployeeSalaryDetailsForm;

    constructor() {
        super();
        this.form = new EmployeeSalaryDetailsForm(this.idPrefix);
    }

    protected override afterLoadEntity() {
        super.afterLoadEntity();

        this.form.ComponentId.changeSelect2(e => {
            var componentId = this.form.ComponentId.value;
            if (isEmptyOrNull(componentId))
                return;

            var component = SalaryComponentsRow.getLookup().itemById[componentId];
            if (component) {
                // We can set defaults here if needed
                // this.form.Amount.value = component.DefaultAmount;
            }
        });
    }

    protected override getSaveEntity() {
        var row = super.getSaveEntity();

        // Populate implicit fields from lookup
        if (row.ComponentId) {
            var component = SalaryComponentsRow.getLookup().itemById[row.ComponentId];
            if (component) {
                row.ComponentName = component.ComponentName;
                row.ComponentType = component.ComponentType;

                // Also default the amount if 0? Maybe not.
            }
        }

        return row;
    }
}
