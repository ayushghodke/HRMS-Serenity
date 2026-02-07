import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { EmployeeDocsForm, EmployeeDocsRow, EmployeeDocsService } from '../../ServerTypes/HR';

@Decorators.registerClass('HRMS.HR.EmployeeDocsDialog')
export class EmployeeDocsDialog extends EntityDialog<EmployeeDocsRow, any> {
    protected getFormKey() { return EmployeeDocsForm.formKey; }
    protected getRowDefinition() { return EmployeeDocsRow; }
    protected getService() { return EmployeeDocsService.baseUrl; }

    protected form = new EmployeeDocsForm(this.idPrefix);
}
