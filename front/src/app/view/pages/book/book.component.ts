import { Component, OnInit } from '@angular/core';
import { GetAllBookUsecase } from 'src/app/core/usecases/book/get-all-book.usecase';
import { CreateBookUsecase } from 'src/app/core/usecases/book/create-book.usecase';
import { DeleteBookUsecase } from 'src/app/core/usecases/book/delete-book.usecase';
import { EditBookUsecase } from 'src/app/core/usecases/book/edit-book.usecase';
import { BookModel } from 'src/app/core/models/book.model';
import { PageResultModel } from 'src/app/core/utils/responses/page-result.model';
import { GetBookByProjectionUsecase } from 'src/app/core/usecases/book/get-book-by-projection.usecase';
import { PageCustomSearchFilterModel } from 'src/app/core/models/page-custom-search-filter.model';

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

  currentPage = 1;
  itemsPerPage = 5;

  isSearch = false;

  ngOnInit(): void {
    this.loadPage()
  }

  loadSearch(): void {
    var bookProjectionModel = {
      propName: this.searchCriteria,
      value: this.searchValue,
      pageSize: this.itemsPerPage,
      pageNumber: this.currentPage
    } as PageCustomSearchFilterModel;

    if(!this.isSearch){
      this.isSearch = true;
      this.currentPage = 1;
    }
    this.getBookByProjection
      .execute(bookProjectionModel)
      .subscribe((grid: PageResultModel<BookModel>) => {
        this.dataSource = grid.data!;
      });
  }

  ResetPage() {
    this.isSearch = false;
    this.searchCriteria = "";
    this.searchValue = "";
    this.loadPage();
  }

  loadPage() {
    this.getAllBook
      .execute({ pageSize: this.itemsPerPage, pageNumber: this.currentPage })
      .subscribe((grid: PageResultModel<BookModel>) => {
        this.dataSource = grid.data!;
      });
  }

  nextPage() {
    if(this.dataSource!.length >= this.itemsPerPage)
    {
      this.currentPage++;
      if(this.isSearch){
        this.loadSearch();
      }
      else{
        this.loadPage();
      }
    }
  }

  prevPage() {
    console.log(this.currentPage);
    if (this.currentPage > 1) {
      this.currentPage--;
      if(this.isSearch){
        this.loadSearch();
      }
      else{
        this.loadPage();
      }
    }
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
