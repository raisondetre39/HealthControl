import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { IntroductionComponent } from './components/introduction/introduction.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [IntroductionComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ],
})
export class HomeModule { }
