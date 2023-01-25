import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { NameRepositoryService } from './namerepository.service';

describe('NameRepositoryService', () => {
  let service: NameRepositoryService;
  let httpMock: HttpTestingController;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [NameRepositoryService]
    });
    service = TestBed.get(NameRepositoryService);
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call http post to /api/names when adding a name', () => {
    const name = 'Aaron';

    service.add(name).subscribe(value => {
    });

    const request = httpMock.expectOne('/api/names');

    expect(JSON.stringify(request.request.body)).toMatch(name);
    expect(request.request.method).toEqual('POST');
  });
});
