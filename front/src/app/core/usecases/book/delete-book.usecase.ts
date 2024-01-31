import { Injectable } from '@angular/core';
import { UseCase } from '../../utils/bases/use-case';
import { Observable } from 'rxjs';
import { BookRepository } from '../../repositories/book.repository';

@Injectable({
  providedIn: 'root',
})
export class DeleteBookUsecase implements UseCase<string, void> {
  constructor(private bookRepository: BookRepository) {}

  execute(id: string): Observable<void> {
    return this.bookRepository.deleteBook(id);
  }
}
