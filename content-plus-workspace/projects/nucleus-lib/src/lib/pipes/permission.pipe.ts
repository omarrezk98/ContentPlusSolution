import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'permission' })
export class PermissionPipe implements PipeTransform {
  transform(userPermissions: any, partId: Number, permissionId: Number): boolean {
    if (!userPermissions || !partId || !permissionId) return false;
    let x = userPermissions.find(s => s.partTypeId == partId && s.permissionTypeId == permissionId);
    if (x == 'undefined' || x == null || x == undefined) return false;
    return true;
  }
}
