import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { TaskStatus } from "./TaskStatus";

export interface TaskRow {
    TaskId?: number;
    Title?: string;
    Description?: string;
    AssignedTo?: number;
    AssignedBy?: number;
    DueDate?: string;
    Status?: TaskStatus;
    AssignedToFullName?: string;
    AssignedByUsername?: string;
}

export abstract class TaskRow {
    static readonly idProperty = 'TaskId';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'Operations.Task';
    static readonly lookupKey = 'Operations.Task';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<TaskRow>('Operations.Task') }
    static async getLookupAsync() { return getLookupAsync<TaskRow>('Operations.Task') }

    static readonly deletePermission = 'Operations:Task';
    static readonly insertPermission = 'Operations:Task';
    static readonly readPermission = 'Operations:Task';
    static readonly updatePermission = 'Operations:Task';

    static readonly Fields = fieldsProxy<TaskRow>();
}