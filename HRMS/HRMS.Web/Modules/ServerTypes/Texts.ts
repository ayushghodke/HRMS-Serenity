import { proxyTexts } from "@serenity-is/corelib";

namespace texts {
    export declare namespace Db {
        export function asKey(): typeof Db;
        export function asTry(): typeof Db;
        namespace Administration {
            export function asKey(): typeof Administration;
            export function asTry(): typeof Administration;
            namespace Language {
                export function asKey(): typeof Language;
                export function asTry(): typeof Language;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const LanguageId: string;
                export const LanguageName: string;
            }
            namespace Role {
                export function asKey(): typeof Role;
                export function asTry(): typeof Role;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const RoleId: string;
                export const RoleName: string;
            }
            namespace RolePermission {
                export function asKey(): typeof RolePermission;
                export function asTry(): typeof RolePermission;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const PermissionKey: string;
                export const RoleId: string;
                export const RoleName: string;
                export const RolePermissionId: string;
            }
            namespace User {
                export function asKey(): typeof User;
                export function asTry(): typeof User;
                export const DisplayName: string;
                export const Email: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const InsertDate: string;
                export const InsertUserId: string;
                export const IsActive: string;
                export const LastDirectoryUpdate: string;
                export const Password: string;
                export const PasswordConfirm: string;
                export const PasswordHash: string;
                export const PasswordSalt: string;
                export const Roles: string;
                export const Source: string;
                export const UpdateDate: string;
                export const UpdateUserId: string;
                export const UserId: string;
                export const UserImage: string;
                export const Username: string;
            }
            namespace UserPermission {
                export function asKey(): typeof UserPermission;
                export function asTry(): typeof UserPermission;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const Granted: string;
                export const PermissionKey: string;
                export const User: string;
                export const UserId: string;
                export const UserPermissionId: string;
                export const Username: string;
            }
            namespace UserRole {
                export function asKey(): typeof UserRole;
                export function asTry(): typeof UserRole;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const RoleId: string;
                export const RoleName: string;
                export const User: string;
                export const UserId: string;
                export const UserRoleId: string;
                export const Username: string;
            }
        }
        namespace HR {
            export function asKey(): typeof HR;
            export function asTry(): typeof HR;
            namespace Department {
                export function asKey(): typeof Department;
                export function asTry(): typeof Department;
                export const DepartmentId: string;
                export const DepartmentName: string;
                export const Description: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const IsActive: string;
            }
            namespace Designation {
                export function asKey(): typeof Designation;
                export function asTry(): typeof Designation;
                export const DesignationId: string;
                export const DesignationName: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const IsActive: string;
                export const Level: string;
            }
            namespace Employee {
                export function asKey(): typeof Employee;
                export function asTry(): typeof Employee;
                export const DateOfBirth: string;
                export const DepartmentId: string;
                export const DepartmentName: string;
                export const DesignationId: string;
                export const DesignationName: string;
                export const Email: string;
                export const EmployeeCode: string;
                export const EmployeeId: string;
                export const EmploymentType: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const FirstName: string;
                export const FullName: string;
                export const Gender: string;
                export const JoiningDate: string;
                export const LastName: string;
                export const ManagerFullName: string;
                export const ManagerId: string;
                export const Phone: string;
                export const Status: string;
                export const UserId: string;
                export const UserImage: string;
                export const Username: string;
            }
        }
        namespace Operations {
            export function asKey(): typeof Operations;
            export function asTry(): typeof Operations;
            namespace Attendance {
                export function asKey(): typeof Attendance;
                export function asTry(): typeof Attendance;
                export const ApprovedBy: string;
                export const ApprovedByUsername: string;
                export const Coordinates: string;
                export const DateNTime: string;
                export const Distance: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const Id: string;
                export const Location: string;
                export const Name: string;
                export const NameUsername: string;
                export const PunchIn: string;
                export const PunchOut: string;
                export const PunchOutCoordinates: string;
                export const Type: string;
                export const UserId: string;
            }
            namespace Leave {
                export function asKey(): typeof Leave;
                export function asTry(): typeof Leave;
                export const ApprovedBy: string;
                export const ApprovedByUsername: string;
                export const CreatedDate: string;
                export const EmployeeFullName: string;
                export const EmployeeId: string;
                export const EndDate: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const LeaveId: string;
                export const LeaveType: string;
                export const Reason: string;
                export const StartDate: string;
                export const Status: string;
                export const TotalDays: string;
            }
            namespace LeaveBalance {
                export function asKey(): typeof LeaveBalance;
                export function asTry(): typeof LeaveBalance;
                export const Allocated: string;
                export const Balance: string;
                export const EmployeeFullName: string;
                export const EmployeeId: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const LeaveBalanceId: string;
                export const LeaveType: string;
                export const Used: string;
                export const Year: string;
            }
            namespace Payroll {
                export function asKey(): typeof Payroll;
                export function asTry(): typeof Payroll;
                export const Allowances: string;
                export const BasicSalary: string;
                export const Deductions: string;
                export const EmployeeFullName: string;
                export const EmployeeId: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const GeneratedDate: string;
                export const Month: string;
                export const NetSalary: string;
                export const PayrollId: string;
                export const Year: string;
            }
            namespace Task {
                export function asKey(): typeof Task;
                export function asTry(): typeof Task;
                export const AssignedBy: string;
                export const AssignedByUsername: string;
                export const AssignedTo: string;
                export const AssignedToFullName: string;
                export const Description: string;
                export const DueDate: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const Status: string;
                export const TaskId: string;
                export const Title: string;
            }
        }
        namespace Recruitment {
            export function asKey(): typeof Recruitment;
            export function asTry(): typeof Recruitment;
            namespace Candidates {
                export function asKey(): typeof Candidates;
                export function asTry(): typeof Candidates;
                export const AppliedDate: string;
                export const CandidateId: string;
                export const Email: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const FirstName: string;
                export const JobId: string;
                export const JobTitle: string;
                export const LastName: string;
                export const Mobile: string;
                export const ResumePath: string;
                export const Status: string;
            }
            namespace Interviews {
                export function asKey(): typeof Interviews;
                export function asTry(): typeof Interviews;
                export const CandidateId: string;
                export const CandidateName: string;
                export const Comments: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const InterviewDate: string;
                export const InterviewId: string;
                export const InterviewerId: string;
                export const InterviewerName: string;
                export const Rating: string;
                export const Round: string;
            }
            namespace JobOpenings {
                export function asKey(): typeof JobOpenings;
                export function asTry(): typeof JobOpenings;
                export const CreatedDate: string;
                export const DepartmentId: string;
                export const DepartmentName: string;
                export const Description: string;
                export const EntityPlural: string;
                export const EntitySingular: string;
                export const HiringManagerId: string;
                export const HiringManagerName: string;
                export const JobId: string;
                export const Status: string;
                export const Title: string;
            }
        }
    }
    export declare namespace Forms {
        export function asKey(): typeof Forms;
        export function asTry(): typeof Forms;
        namespace Membership {
            export function asKey(): typeof Membership;
            export function asTry(): typeof Membership;
            namespace Login {
                export function asKey(): typeof Login;
                export function asTry(): typeof Login;
                export const ForgotPassword: string;
                export const LoginToYourAccount: string;
                export const RememberMe: string;
                export const SignInButton: string;
                export const SignUpButton: string;
            }
            namespace SignUp {
                export function asKey(): typeof SignUp;
                export function asTry(): typeof SignUp;
                export const ActivateEmailSubject: string;
                export const ActivationCompleteMessage: string;
                export const ConfirmEmail: string;
                export const ConfirmPassword: string;
                export const DisplayName: string;
                export const Email: string;
                export const FormInfo: string;
                export const FormTitle: string;
                export const Password: string;
                export const SubmitButton: string;
                export const Success: string;
            }
        }
        export const SiteTitle: string;
    }
    export declare namespace Site {
        export function asKey(): typeof Site;
        export function asTry(): typeof Site;
        namespace AccessDenied {
            export function asKey(): typeof AccessDenied;
            export function asTry(): typeof AccessDenied;
            export const ClickToChangeUser: string;
            export const ClickToLogin: string;
            export const LackPermissions: string;
            export const NotLoggedIn: string;
            export const PageTitle: string;
        }
        namespace Layout {
            export function asKey(): typeof Layout;
            export function asTry(): typeof Layout;
            export const Language: string;
            export const Theme: string;
        }
        namespace RolePermissionDialog {
            export function asKey(): typeof RolePermissionDialog;
            export function asTry(): typeof RolePermissionDialog;
            export const DialogTitle: string;
            export const EditButton: string;
            export const SaveSuccess: string;
        }
        namespace UserDialog {
            export function asKey(): typeof UserDialog;
            export function asTry(): typeof UserDialog;
            export const EditPermissionsButton: string;
            export const EditRolesButton: string;
        }
        namespace UserPermissionDialog {
            export function asKey(): typeof UserPermissionDialog;
            export function asTry(): typeof UserPermissionDialog;
            export const DialogTitle: string;
            export const Grant: string;
            export const Permission: string;
            export const Revoke: string;
            export const SaveSuccess: string;
        }
        namespace ValidationError {
            export function asKey(): typeof ValidationError;
            export function asTry(): typeof ValidationError;
            export const Title: string;
        }
    }
    export declare namespace Validation {
        export function asKey(): typeof Validation;
        export function asTry(): typeof Validation;
        export const AuthenticationError: string;
        export const CurrentPasswordMismatch: string;
        export const DeleteForeignKeyError: string;
        export const EmailConfirm: string;
        export const EmailInUse: string;
        export const InvalidActivateToken: string;
        export const InvalidResetToken: string;
        export const MinRequiredPasswordLength: string;
        export const PasswordConfirmMismatch: string;
        export const SavePrimaryKeyError: string;
    }

}

const Texts: typeof texts = proxyTexts({}, '', {
    Db: {
        Administration: {
            Language: {},
            Role: {},
            RolePermission: {},
            User: {},
            UserPermission: {},
            UserRole: {}
        },
        HR: {
            Department: {},
            Designation: {},
            Employee: {}
        },
        Operations: {
            Attendance: {},
            Leave: {},
            LeaveBalance: {},
            Payroll: {},
            Task: {}
        },
        Recruitment: {
            Candidates: {},
            Interviews: {},
            JobOpenings: {}
        }
    },
    Forms: {
        Membership: {
            Login: {},
            SignUp: {}
        }
    },
    Site: {
        AccessDenied: {},
        Layout: {},
        RolePermissionDialog: {},
        UserDialog: {},
        UserPermissionDialog: {},
        ValidationError: {}
    },
    Validation: {}
}) as any;

export const AccessDeniedViewTexts = Texts.Site.AccessDenied;
export const LoginFormTexts = Texts.Forms.Membership.Login;
export const MembershipValidationTexts = Texts.Validation;
export const RolePermissionDialogTexts = Texts.Site.RolePermissionDialog;
export const SignUpFormTexts = Texts.Forms.Membership.SignUp;
export const SiteFormTexts = Texts.Forms;
export const SiteLayoutTexts = Texts.Site.Layout;
export const SqlExceptionHelperTexts = Texts.Validation;
export const UserDialogTexts = Texts.Site.UserDialog;
export const UserPermissionDialogTexts = Texts.Site.UserPermissionDialog;
export const ValidationErrorViewTexts = Texts.Site.ValidationError;