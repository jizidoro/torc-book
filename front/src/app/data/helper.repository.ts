import { HttpParams } from '@angular/common/http';
import { PageCustomFilterModel } from '../core/utils/filters/page-custom-filter.model';
import { PageFilterModel, ParamCustom } from '../core/utils/filters/page-filter.model';
import { PageCustomSearchFilterModel } from '../core/models/page-custom-search-filter.model';

export const makeParamFilterGrid = (filter: PageFilterModel): string => {
  const filters = [];
  if (filter.status) {
    filters.push(`status=${filter.status}`);
  }

  if (filter.pageNumber != null) {
    filters.push(`pageNumber=${filter.pageNumber}`);
  } else {
    filters.push(`pageNumber=${0}`);
  }

  if (filter.pageSize != null) {
    filters.push(`pageSize=${filter.pageSize}`);
  } else {
    filters.push(`pageSize=${1000}`);
  }

  (filter.custom || []).map((c: any) => {
    filters.push(`${c.key}=${c.value}`);
  });

  return filters.length > 0 ? `?${filters.join('&')}` : '';
};

export const makeParamCustomFilter = (filter: PageCustomFilterModel): string => {
  const filters: any[] = [];

  (filter.custom || []).map((c: any) => {
    filters.push(c);
  });

  return filters.length > 0 ? `?${filters.join('&')}` : '';
};

export const makeParamCustomSearchFilter = (filter: PageCustomSearchFilterModel): string => {
  const filters: any[] = [];

  if (filter.pageNumber != null) {
    filters.push(`pageNumber=${filter.pageNumber}`);
  } else {
    filters.push(`pageNumber=${0}`);
  }

  if (filter.pageSize != null) {
    filters.push(`pageSize=${filter.pageSize}`);
  } else {
    filters.push(`pageSize=${1000}`);
  }

  if (filter.propName != null) {
    filters.push(`propName=${filter.propName}`);
  }

  if (filter.value != null) {
    filters.push(`value=${filter.value}`);
  }

  (filter.custom || []).map((c: any) => {
    filters.push(c);
  });
  var oto = `?${filters.join('&')}`;
  console.log(oto);
  return filters.length > 0 ? `?${filters.join('&')}` : '';
};

export const makeParamFilterList = (filter: PageFilterModel): string => {
  const filters: any[] = [];

  (filter.custom || []).map((c: ParamCustom) => {
    filters.push(`${c.key}=${c.value}`);
  });

  return filters.length > 0 ? `?${filters.join('&')}` : '';
};
