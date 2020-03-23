export interface IDisease {
    diseaseName: string;
    id: number;
}

export interface IDiseaseInfo {
    diseases: IDisease[];
    count: number;
}
