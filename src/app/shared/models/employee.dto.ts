
export class EmployeeDto {

    constructor() {
        this.id = 0;
        this.username = '';
        this.password = '';
        this.firstName = '';
        this.surname = '';
        this.jobTitle = '';
        this.isAdmin = false;
    }

    id: number;
    username: string;
    password: string;
    firstName: string;
    surname: string;
    jobTitle: string;
    isAdmin: boolean;
}
