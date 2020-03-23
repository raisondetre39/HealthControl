import { Role } from '../extension/roles';

export interface IUser {
    token?: string;
    role: Role;
}

export interface ICreateUser {
    Email: string;
    Password: string;
    FirstName: string;
    LastName: string;
    DiseaseId: number;
}

export interface IUserPartialInfo {
    email: string;
    firstName: string;
    lastName: string;
    diseaseName: string;
    diseaseId: number;
}

