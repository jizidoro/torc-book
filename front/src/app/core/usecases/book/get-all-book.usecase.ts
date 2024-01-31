import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { PageFilterModel } from '../../utils/filters/page-filter.model';
import { PageResultModel } from '../../utils/responses/page-result.model';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';

@Injectable({
  providedIn: 'root',
})
export class GetAllBookUsecase implements UseCase<PageFilterModel, PageResultModel<BookModel>> {
  constructor(private bookRepository: BookRepository) {}

  execute(filter: PageFilterModel): Observable<PageResultModel<BookModel>> {
    return this.bookRepository.getAllBook(filter);
  }
}
