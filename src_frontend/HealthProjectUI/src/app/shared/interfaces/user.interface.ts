import { Role } from '../extension/roles';

export interface IUser {
    token?: string;
    role: Role;
}
