import { Ng2PracticeAppPage } from './app.po';

describe('ng2-practice-app App', () => {
  let page: Ng2PracticeAppPage;

  beforeEach(() => {
    page = new Ng2PracticeAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
