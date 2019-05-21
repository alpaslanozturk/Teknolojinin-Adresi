import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FileUploadModule} from 'ng2-file-upload';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { IndexComponent } from './index/index.component';
import { StoreComponent } from './store/store.component';
import { ProductComponent } from './product/product.component';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AdminComponent } from './admin/admin.component';
import { AdminProductComponent } from './admin/admin-product/admin-product.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { NgxGalleryModule } from 'ngx-gallery';
import { CheckoutComponent } from './checkout/checkout.component';
import { AdminProductDetailComponent } from './admin/admin-product/admin-product-detail/admin-product-detail.component';
import { UploadComponent } from './admin/upload/upload.component';
import { AdminAddProductComponent } from './admin/admin-product/admin-add-product/admin-add-product.component';
import { AdminCategoryComponent } from './admin/admin-category/admin-category.component';
import { AdminAddCategoryComponent } from './admin/admin-category/admin-add-category/admin-add-category.component';
import { AdminCategoryDetailComponent } from './admin/admin-category/admin-category-detail/admin-category-detail.component';

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent,
      FooterComponent,
      IndexComponent,
      StoreComponent,
      ProductComponent,
      LoginComponent,
      RegisterComponent,
      AdminComponent,
      AdminProductComponent,
      ProductDetailComponent,
      CheckoutComponent,
      AdminProductDetailComponent,
      UploadComponent,
      AdminAddProductComponent,
      AdminCategoryComponent,
      AdminAddCategoryComponent,
      AdminCategoryDetailComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      NgxGalleryModule ,
      FileUploadModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: () => {
               return localStorage.getItem('token');
            },
            //whitelistedDomains: [],
            blacklistedRoutes: [],
            skipWhenExpired: true,
         },
      })

   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
