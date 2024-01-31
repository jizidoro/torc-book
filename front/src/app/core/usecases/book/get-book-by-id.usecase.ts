import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';
import { SingleResultModel } from '../../utils/responses/single-result.model';

@Injectable({
  providedIn: 'root',
})
export class GetBookByIdUsecase implements UseCase<string, SingleResultModel<BookModel>> {
  constructor(private bookRepository: BookRepository) {}

  execute(id: string): Observable<SingleResultModel<BookModel>> {
    return this.bookRepository.getBookById(id);
  }
}
