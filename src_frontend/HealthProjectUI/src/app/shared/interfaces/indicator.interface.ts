export interface IIndicator {
    indicatorName: string;
    maxValue: number;
    minValue: number;
    id: number;
}

export interface IIndicatorInfo {
    indicators: IIndicator[];
    count: number;
}

export interface IDotValue {
    dataNumber: number;
    labelName: string;
}

export interface IIndicatorList {
    display: boolean;
    id: number;
    indicatorData: IDotValue[];
}
