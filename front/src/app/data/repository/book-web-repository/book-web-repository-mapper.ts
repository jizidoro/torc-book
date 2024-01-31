import { Mapper } from '../../../core/utils/bases/mapper';
import { BookWebEntity } from './book-web-entity';
import { BookModel } from 'src/app/core/models/book.model';

export class BookWebRepositoryMapper extends Mapper<BookWebEntity, BookModel> {
  mapFrom(param: BookWebEntity): BookModel {
    return {
      id: param.id,
      title: param.title,
      firstName: param.firstName,
      lastName: param.lastName,
      totalCopies: param.totalCopies,
      copiesInUse: param.copiesInUse,
      type: param.type,
      isbn: param.isbn,
      category: param.category,
    };
  }

  mapTo(param: BookModel): BookWebEntity {
    return {
      id: param.id,
      title: param.title,
      firstName: param.firstName,
      lastName: param.lastName,
      totalCopies: param.totalCopies,
      copiesInUse: param.copiesInUse,
      type: param.type,
      isbn: param.isbn,
      category: param.category,
    };
  }
}
