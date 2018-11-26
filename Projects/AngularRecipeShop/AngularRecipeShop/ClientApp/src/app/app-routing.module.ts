import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }




//RouterModule.forRoot([
//  { path: '', component: HomeComponent, pathMatch: 'full' },
//  { path: 'counter', component: CounterComponent },
//  { path: 'fetch-data', component: FetchDataComponent },
//])
