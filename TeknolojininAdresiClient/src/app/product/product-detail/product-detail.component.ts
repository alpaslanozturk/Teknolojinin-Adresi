import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd } from '@angular/router';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { Icomment } from 'src/_models/icomment';
import { ProductsService } from 'src/_services/products.service';
import { CommentsService } from 'src/_services/comments.service';
import { PicturesService } from 'src/_services/pictures.service';
import { IpicturesProduct } from 'src/_models/ipicturesProduct';
import { NgxGalleryImage, NgxGalleryOptions, NgxGalleryAnimation } from 'ngx-gallery';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CartService } from 'src/_services/cart.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: IproductsTopSelling;
  commentsList: Icomment[] = [];
  productId: number;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  picturesUrls = [];
  commentForm: FormGroup;
  star: number;
  values: string;
  quantityHtml: number;

  constructor(private activeRoute: ActivatedRoute, private serviceProducts: ProductsService,
              private serviceComments: CommentsService, private servicePictures: PicturesService,
              private formBuilder: FormBuilder, private serviceCart: CartService) { }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
      window.scrollTo(0, 0);
      this.productId = params['productId'];
      this.getProductDetail(params['productId']);
      this.getGallery();
      this.createCommentForm();
    });
  }

  getProductDetail(productId: number) {
    this.serviceProducts.getProductDetail(productId).subscribe(data => {
      this.product = data;
      this.getComments(productId);
      this.getPictures(productId);
    });
  }

  getComments(productId: number) {
    this.serviceComments.getProductDetail(productId).subscribe(data => {
      this.commentsList = data;
    });
  }

  arrayOne(n: number): any[] {
    n = Math.ceil(n);
    return new Array(n);
  }

  arrayOneEmpty(n: number): any[] {
    n = Math.floor(n);
    return new Array(n);
  }

  getPictures(productId: number) {
    this.servicePictures.getPicturesProduct(productId).subscribe(data => {
      let picturesList: IpicturesProduct[];
      picturesList = data;
      if (picturesList != null) {
        picturesList.forEach(element => {
          this.picturesUrls.push({
            small: element.pictureUrl,
            medium: element.pictureUrl,
            big: element.pictureUrl
          });
        });
      }

      this.picturesUrls.push({
        small: this.product.pictureUrl.replace(/\\/g, '\\\\'),
        medium: this.product.pictureUrl.replace(/\\/g, '\\\\'),
        big: this.product.pictureUrl.replace(/\\/g, '\\\\')
      });
    });
  }

  getGallery() {
    this.galleryOptions = [
      {
          width: '300px',
          height: '300px',
          thumbnailsColumns: 4,
          imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
          breakpoint: 800,
          width: '100%',
          height: '600px',
          imagePercent: 80,
          thumbnailsPercent: 20,
          thumbnailsMargin: 20,
          thumbnailMargin: 20
      },
      // max-width 400
      {
          breakpoint: 400,
          preview: false
      }
  ];
    this.galleryImages = this.picturesUrls;

  }

  yourRating(star: number) {
    this.star = star;
  }

  addComment() {
    this.commentForm.controls['rating'].setValue(this.star);
    this.commentForm.controls['productsId'].setValue(this.productId);
    this.serviceComments.addComment(this.commentForm.value).subscribe(data => {});
    this.getComments(this.productId);
  }

  createCommentForm() {
    this.commentForm = this.formBuilder.group(
      {
        comment: ['', Validators.required],
        rating: [''],
        productsId: ['']
      },
    );
  }
  addCart(quantity: number ,product: IproductsTopSelling) {
    const userId = parseInt( localStorage.getItem('userId') );
    console.log(quantity);
    this.serviceCart.addToCart(userId, quantity, product).subscribe(data => {
    });
  }

  onSearchChange(searchValue : number ) { 
    this.quantityHtml = searchValue; 
  }
}
