import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookWebRepositoryMapper as BookWebRepositoryMapper } from './book-web-repository-mapper';
import { BookWebEntity } from './book-web-entity';
import { map } from 'rxjs/operators';
import { BaseHttpService } from 'src/app/services/http/base-http.service';
import { environment } from 'src/environments/environment';
import { BookRepository } from 'src/app/core/repositories/book.repository';
import { BookModel } from 'src/app/core/models/book.model';
import { PageResultModel } from 'src/app/core/utils/responses/page-result.model';
import { PageFilterModel } from 'src/app/core/utils/filters/page-filter.model';
import { makeParamCustomSearchFilter, makeParamFilterGrid } from '../../helper.repository';
import { SingleResultModel } from '../../../core/utils/responses/single-result.model';
import { HttpParams } from '@angular/common/http';
import { PageCustomSearchFilterModel } from 'src/app/core/models/page-custom-search-filter.model';

@Injectable({
  providedIn: 'root',
})
export class BookWebRepository extends BookRepository {
  mapper = new BookWebRepositoryMapper();

  constructor(public http: BaseHttpService) {
    super();
  }

  getBookById(id: string): Observable<SingleResultModel<BookModel>> {
    PageResultModel;
    return this.http
      .get<SingleResultModel<BookWebEntity>>(`${environment.BOOK}book/get-by-id`, id)
      .pipe(map((x) => this.mapper.responseWebMapFrom(x.data)));
  }

  getAllBook(filter: PageFilterModel): Observable<PageResultModel<BookModel>> {
    var request = this.http
      .getAll<PageResultModel<BookWebEntity>>(
        `${environment.BOOK}book/get-all${makeParamFilterGrid(filter)}`
      )
      .pipe(
        map((x) => {
          return this.mapper.responseGridWebMapFrom(x.data);
        })
      );
    return request;
  }

  getBookByProjection(filter: PageCustomSearchFilterModel): Observable<PageResultModel<BookModel>> {
    console.log("filter");
    console.log(filter);
    var request = this.http
    .getAll<PageResultModel<BookWebEntity>>(
      `${environment.BOOK}book/get-by-projection${makeParamCustomSearchFilter(filter)}`
    )
    .pipe(
      map((x) => {
        return this.mapper.responseGridWebMapFrom(x.data);
      })
    );
    return request;
  }

  createBook(param: BookModel) {
    return this.http
      .post<BookWebEntity>(`${environment.BOOK}book/create`, this.mapper.mapTo(param))
      .pipe(map((x) => this.mapper.mapFrom(x.data)));
  }

  editBook(param: BookModel) {
    return this.http
      .put<void>(`${environment.BOOK}book/edit`, this.mapper.mapTo(param))
      .pipe(map((x) => x.data));
  }

  deleteBook(id: string): Observable<void> {
    return this.http
      .delete<void>(`${environment.BOOK}book/delete/${id}`, id)
      .pipe(map((x) => x.data));
  }
}
