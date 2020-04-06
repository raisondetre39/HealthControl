import { Component, OnInit , ViewChild, OnDestroy } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, BaseChartDirective, Label } from 'ng2-charts';
import * as pluginAnnotations from 'chartjs-plugin-annotation';
import { AnalyticsService } from './analytics.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { IDeviceInfo, IIndicatorValue, IDeviceIndicator } from 'src/app/shared/interfaces/user.interface';
import { IIndicatorList, IDotValue } from 'src/app/shared/interfaces/indicator.interface';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.css']
})
export class AnalyticsComponent implements OnInit, OnDestroy {

  generateData: IIndicatorList[] = [];
  firstCall = false;
  public lineChartData: ChartDataSets[] = [
    { data: [0], label: 'Noun' },
  ];
  public lineChartLabels: Label[] = [];
  public lineChartOptions: (ChartOptions & { annotation: any }) = {
    responsive: true,
    scales: {
      xAxes: [{}],
      yAxes: [
        {
          id: 'y-axis-0',
          position: 'left',
        }
      ]
    },
    annotation: null
  };
  public lineChartColors: Color[] = [
    {
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [pluginAnnotations];
  deviceIndicator: IDeviceInfo;

  @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;
  private destroy$ = new Subject<void>();
  constructor(private analyticsService: AnalyticsService) { }

  ngOnInit() {
    this.getDeviceInfo();
  }

  getDeviceInfo() {
    this.analyticsService.getDevice(3)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          this.deviceIndicator = res;
          this.setData();
        },
        () => {
        }
      );
  }

  setData() {
    this.deviceIndicator.deviceIndicators.forEach((deviceIndicators: IDeviceIndicator) => {
      const dataVal = [];
      deviceIndicators.indicatorValues.forEach(( data: IIndicatorValue ) => {
        dataVal.push( {
          dataNumber: data.value,
          labelName: data.date
        });
      });
      this.generateData.push(
        {
          display: false,
          id: deviceIndicators.indicatorId,
          indicatorData: dataVal
        }
      );
    });
  }

  displayGrap(indicatorId: number): void {
    this.firstCall = true;
    this.getLineChartData(indicatorId);
    this.getlineChartLabels(indicatorId);
  }

  getLineChartData(indicatorId: number) {
    const dataX = [];
    this.generateData.find(x => x.id === indicatorId)
      .indicatorData.forEach((data: IDotValue) => dataX.push(data.dataNumber));
    this.lineChartData = [{ data: dataX, label: 'Fddasd'}];
  }

  getlineChartLabels(indicatorId: number) {
    const dataY: Label[] = [];
    this.generateData.find(x => x.id === indicatorId)
      .indicatorData.forEach((data: IDotValue) => dataY.push(data.labelName));
    this.lineChartLabels = dataY;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
