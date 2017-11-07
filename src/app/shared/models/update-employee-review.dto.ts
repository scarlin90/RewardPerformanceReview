
export class UpdateEmployeeReviewDto {

    constructor() {
        this.id = 0;
        this.employeeId = 0;
        this.objectives = '';
        this.overallPerformance = '';
        this.technicalPerformance = '';
        this.deliveringResults = '';
        this.communications = '';
        this.leadership = '';
        this.aspirations = '';
    }

    id: number;
    employeeId: number;
    objectives: string;
    overallPerformance: string;
    technicalPerformance: string;
    deliveringResults: string;
    communications: string;
    leadership: string;
    aspirations: string;
}
