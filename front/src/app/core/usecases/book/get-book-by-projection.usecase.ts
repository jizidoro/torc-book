import { GetAllBookUsecase } from 'src/app/core/usecases/book/get-all-book.usecase';
import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { PageFilterModel } from '../../utils/filters/page-filter.model';
import { PageResultModel } from '../../utils/responses/page-result.model';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';
import { BookProjectionModel } from '../../models/book.projection.model';

@Injectable({
  providedIn: 'root',
})
export class GetBookByProjectionUsecase
  implements UseCase<BookProjectionModel, PageResultModel<BookModel>>
{
  constructor(private bookRepository: BookRepository) {}

  execute(filter: BookProjectionModel): Observable<PageResultModel<BookModel>> {
    return this.bookRepository.getBookByProjection(filter);
  }
}
