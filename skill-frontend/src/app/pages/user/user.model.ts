export interface User {
    isEnable: boolean;

    image: string;
    background: string;
    name: string;
    description: string;
    age: number;
    email: string;
    phone: string;
    address: string;
    type: UserType;
    category: UserCategory;
    currentPosition: string;
    currentCompany: string;
    currentWage: number;
    jobApplications: number;
    jobApplicationsApproved: number;
    jobInterviews: number;
    skills: any[];
}

export enum UserType {
    Unemployed = 1,
    employee = 2
}

export enum UserCategory {
    normal = 1,
    technical = 2,
    humanResources = 3
}
