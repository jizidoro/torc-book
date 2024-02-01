import { GetAllBookUsecase } from 'src/app/core/usecases/book/get-all-book.usecase';
import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { PageFilterModel } from '../../utils/filters/page-filter.model';
import { PageResultModel } from '../../utils/responses/page-result.model';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';
import { PageCustomSearchFilterModel } from '../../models/page-custom-search-filter.model';

@Injectable({
  providedIn: 'root',
})
export class GetBookByProjectionUsecase
  implements UseCase<PageCustomSearchFilterModel, PageResultModel<BookModel>>
{
  constructor(private bookRepository: BookRepository) {}

  execute(filter: PageCustomSearchFilterModel): Observable<PageResultModel<BookModel>> {
    return this.bookRepository.getBookByProjection(filter);
  }
}
