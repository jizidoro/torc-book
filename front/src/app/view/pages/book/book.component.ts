import { Component, OnInit } from '@angular/core';
import { GetAllBookUsecase } from 'src/app/core/usecases/book/get-all-book.usecase';
import { CreateBookUsecase } from 'src/app/core/usecases/book/create-book.usecase';
import { DeleteBookUsecase } from 'src/app/core/usecases/book/delete-book.usecase';
import { EditBookUsecase } from 'src/app/core/usecases/book/edit-book.usecase';
import { BookModel } from 'src/app/core/models/book.model';
import { PageResultModel } from 'src/app/core/utils/responses/page-result.model';
import { GetBookByProjectionUsecase } from 'src/app/core/usecases/book/get-book-by-projection.usecase';
import { BookProjectionModel } from 'src/app/core/models/book.projection.model';

@Component({
  selector: 'app-book',
  templateUrl: 'book.component.html',
  styleUrls: ['book.component.scss'],
  providers: [],
})
export class BookComponent implements OnInit {
  dataSource?: BookModel[];
  constructor(
    private getBookByProjection: GetBookByProjectionUsecase,
    private getAllBook: GetAllBookUsecase,
    private createBook: CreateBookUsecase,
    private deleteBook: DeleteBookUsecase,
    private editBook: EditBookUsecase
  ) {}

  searchCriteria: string = '';
  searchValue: string = '';

  ngOnInit(): void {
    this.getAllBook
      .execute({ pageSize: 10, pageNumber: 1 })
      .subscribe((grid: PageResultModel<BookModel>) => {
        console.log(grid.data);
        this.dataSource = grid.data!;
      });
  }

  onSearch(): void {
    var bookProjectionModel = {
      propName: this.searchCriteria,
      value: this.searchValue,
    } as BookProjectionModel;

    console.log(bookProjectionModel);
    this.getBookByProjection
      .execute(bookProjectionModel)
      .subscribe((grid: PageResultModel<BookModel>) => {
        this.dataSource = grid.data!;
      });
  }

  delete(e: any): void {
    this.deleteBook.execute(e.key).subscribe();
  }

  save(e: any): void {
    this.createBook.execute(e.data).subscribe();
  }

  update(e: any): void {
    this.editBook.execute(e.data).subscribe();
  }
}
