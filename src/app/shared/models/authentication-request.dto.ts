
export class AuthenticateRequestDto {

    constructor() {
        this.username = '';
        this.password = '';
    }

    username: string;
    password: string;
}
