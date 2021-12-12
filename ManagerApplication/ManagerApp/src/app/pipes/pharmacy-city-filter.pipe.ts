import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pharmacyCityFilter'
})
export class PharmacyCityFilterPipe implements PipeTransform {

  transform(value: any, filterString: string) {
    if (value.length === 0) {
      return value;
    }
    let pharmacies = [];
    for (let pharmacy of value) {
      if (pharmacy['city'].toLowerCase().includes(filterString.toLowerCase())) {
        pharmacies.push(pharmacy);
      }
    }
    return pharmacies;
  }

}
