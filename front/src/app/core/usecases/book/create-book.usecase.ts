import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';

@Injectable({
  providedIn: 'root',
})
export class CreateBookUsecase implements UseCase<BookModel, BookModel> {
  constructor(private bookRepository: BookRepository) {}

  execute(params: BookModel): Observable<BookModel> {
    return this.bookRepository.createBook(params);
  }
}
