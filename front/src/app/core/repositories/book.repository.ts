import { Observable } from 'rxjs';
import { BookModel } from '../models/book.model';
import { PageFilterModel } from '../utils/filters/page-filter.model';
import { PageResultModel } from '../utils/responses/page-result.model';
import { SingleResultModel } from '../utils/responses/single-result.model';
import { BookProjectionModel } from '../models/book.projection.model';

export abstract class BookRepository {
  abstract getBookById(id: string): Observable<SingleResultModel<BookModel>>;
  abstract getBookByProjection(filter: BookProjectionModel): Observable<PageResultModel<BookModel>>;
  abstract getAllBook(filter: PageFilterModel): Observable<PageResultModel<BookModel>>;
  abstract createBook(param: BookModel): Observable<BookModel>;
  abstract editBook(param: BookModel): Observable<void>;
  abstract deleteBook(id: string): Observable<void>;
}
