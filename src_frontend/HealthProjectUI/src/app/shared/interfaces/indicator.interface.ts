export interface IIndicator {
    indicatorName: string;
    maxValue: number;
    minValue: number;
    id: number;
}

export interface IIndicatorInfo {
    indicators: IIndicator;
    count: number;
}
