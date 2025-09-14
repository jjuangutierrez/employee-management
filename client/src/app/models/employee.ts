import { DocumentType } from "./enums/document-type"
import { Role } from "./enums/role"
import { State } from "./enums/state"

export interface Employee {
    id: number;
    name: string;
    lastName: string;
    age: number;
    documentNumber: number;
    documentType: DocumentType;
    hireDate: Date;
    role: Role;
    state: State;
    email: string;
    password: string;
    phone: number;
    alternatePhone: number;
    houseDirection: string;
    salary: number;
    position: string
}
