import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { BookModel } from '../../models/book.model';
import { BookRepository } from '../../repositories/book.repository';

@Injectable({
  providedIn: 'root',
})
export class EditBookUsecase implements UseCase<BookModel, void> {
  constructor(private processoRepository: BookRepository) {}

  execute(params: BookModel): Observable<void> {
    return this.processoRepository.editBook(params);
  }
}
