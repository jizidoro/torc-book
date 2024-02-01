import { PageFilterModel } from "../utils/filters/page-filter.model";

export interface PageCustomSearchFilterModel extends PageFilterModel {
  propName: string;
  value: string;
}
