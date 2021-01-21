import { Component, Input, Output, EventEmitter } from '@angular/core';
import { faFastBackward, faStepBackward, faFastForward, faStepForward } from '@fortawesome/free-solid-svg-icons';

import { Paging } from './../../../../models/base/Paging';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html'
})
export class PagingComponent {
  @Input() paging: Paging;
  @Output() handlePageChange: EventEmitter<number> = new EventEmitter();

  faFastBackward = faFastBackward;
  faStepBackward = faStepBackward;
  faFastForward = faFastForward;
  faStepForward = faStepForward;

  onChangePage(event: MouseEvent, page: number) {
    event.preventDefault();
    this.handlePageChange.emit(page);
  }

  range(n: number) {
    return [...Array(n).keys()];
  }
}
