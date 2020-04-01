import { Role } from '../extension/roles';

export interface IUser {
    token?: string;
    role: Role;
}

export interface ICreateUser {
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    diseaseId: number;
}

export interface IUserPartialInfo {
    email: string;
    firstName: string;
    lastName: string;
    diseaseName: string;
    diseaseId: number;
}

