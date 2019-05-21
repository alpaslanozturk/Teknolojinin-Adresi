import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProductComponent } from './product/product.component';
import { StoreComponent } from './store/store.component';
import { AdminGuard } from './guards/admin.guard';
import { AdminProductComponent } from './admin/admin-product/admin-product.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AdminAddProductComponent } from './admin/admin-product/admin-add-product/admin-add-product.component';
import { AdminCategoryComponent } from './admin/admin-category/admin-category.component';
import { AdminAddCategoryComponent } from './admin/admin-category/admin-add-category/admin-add-category.component';

const routes: Routes = [
  {path: 'index', component: IndexComponent },
  {path: '', component: IndexComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'product', component: ProductComponent},
  {path: 'store/:categoryId/:search', component: StoreComponent},
  {path: 'store/:categoryId', component: StoreComponent},
  {path: 'productDetail/:productId', component: ProductDetailComponent},
  {path: 'checkout/:cartsId', component: CheckoutComponent},
  {path: 'adminProduct', component: AdminProductComponent, canActivate: [AdminGuard]},
  {path: 'addProduct', component: AdminAddProductComponent, canActivate: [AdminGuard]},
  {path: 'adminCategory', component: AdminCategoryComponent, canActivate: [AdminGuard]},
  {path: 'addCategory', component: AdminAddCategoryComponent, canActivate: [AdminGuard]},
  {path: '**', redirectTo: '', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
