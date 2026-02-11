import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SalaryGradeRow } from "./SalaryGradeRow";

export interface SalaryGradeColumns {
    GradeId: Column<SalaryGradeRow>;
    GradeName: Column<SalaryGradeRow>;
    GradeCode: Column<SalaryGradeRow>;
    MinSalary: Column<SalaryGradeRow>;
    MaxSalary: Column<SalaryGradeRow>;
    IsActive: Column<SalaryGradeRow>;
}

export class SalaryGradeColumns extends ColumnsBase<SalaryGradeRow> {
    static readonly columnsKey = 'Operations.SalaryGrade';
    static readonly Fields = fieldsProxy<SalaryGradeColumns>();
}