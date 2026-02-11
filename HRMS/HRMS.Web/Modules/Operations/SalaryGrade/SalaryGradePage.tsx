import { initFullHeightGridPage } from '@serenity-is/corelib';
import { SalaryGradeGrid } from './SalaryGradeGrid';

export default function pageInit() {
    initFullHeightGridPage(new SalaryGradeGrid($('#GridDiv')).element);
}
