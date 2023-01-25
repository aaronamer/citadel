import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HomeComponent } from './home.component';
import { NameRepositoryService } from '../../services/namerepository.service';

describe('HomeComponent', () => {
  let fixture: ComponentFixture<HomeComponent>;
  let componentInstance: any;

  beforeEach(() => {

    TestBed.configureTestingModule({
      imports: [FormsModule, ReactiveFormsModule, HttpClientTestingModule],
      providers: [NameRepositoryService],
      declarations: [HomeComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    componentInstance = fixture.debugElement.componentInstance;
  });

  it('should create the home component', () => {
    expect(componentInstance).toBeTruthy();
  });

  it('should show an error message if the user submits an empty name', () => {
    fixture.detectChanges();

    const button: HTMLElement = fixture.nativeElement.querySelector('button');
    expect(button).toBeTruthy();

    button.click();
    fixture.detectChanges();

    const errorMsg = fixture.nativeElement.querySelector('.invalid-feedback');
    expect(errorMsg).toBeTruthy();
  });

  it('should show an error message if the user submits a whitspace only name', () => {
    fixture.detectChanges();

    const input: HTMLInputElement = fixture.nativeElement.querySelector('input');
    expect(input).toBeTruthy();
    input.value = '     ';

    const button: HTMLElement = fixture.nativeElement.querySelector('.btn-primary');
    expect(button).toBeTruthy();

    button.click();
    fixture.detectChanges();

    const errorMsg = fixture.nativeElement.querySelector('.invalid-feedback');
    expect(errorMsg).toBeTruthy();
  });

  it('should not show an error message until submit is clicked', () => {
    fixture.detectChanges();

    const input: HTMLInputElement = fixture.nativeElement.querySelector('input');
    expect(input).toBeTruthy();
    input.value = '     ';

    const button: HTMLElement = fixture.nativeElement.querySelector('.btn-primary');
    expect(button).toBeTruthy();

    let errorMsg = fixture.nativeElement.querySelector('.invalid-feedback');
    expect(errorMsg).toBeNull();

    button.click();
    fixture.detectChanges();

    errorMsg = fixture.nativeElement.querySelector('.invalid-feedback');
    expect(errorMsg).toBeTruthy();
  });
});
