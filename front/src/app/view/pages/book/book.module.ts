import { NgModule, Optional, SkipSelf } from '@angular/core';
import { BookRoutingModule } from './book.routing';
import { throwIfAlreadyLoaded } from '../../../services/guards/module-import.guard';
import { BookComponent } from './book.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [BookRoutingModule, CommonModule, FormsModule],
  exports: [],
  declarations: [BookComponent],
  providers: [],
})
export class BookModule {
  constructor(@Optional() @SkipSelf() parentModule: BookModule) {
    throwIfAlreadyLoaded(parentModule, 'BookModule');
  }
}
