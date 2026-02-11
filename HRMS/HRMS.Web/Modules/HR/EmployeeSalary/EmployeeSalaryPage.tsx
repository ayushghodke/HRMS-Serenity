import { initFullHeightGridPage } from '@serenity-is/corelib';
import { EmployeeSalaryGrid } from './EmployeeSalaryGrid';

export default function pageInit() {
    initFullHeightGridPage(new EmployeeSalaryGrid($('#GridDiv')).element);
}
