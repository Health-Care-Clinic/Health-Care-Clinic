export interface IFeedback {
    id: number;
    date: Date;
    text: string;
    isAnonymous: boolean;
    identity: string;
    canBePublished :boolean;
    isPublished: boolean;
  }
  
  export const feedbacks = [
    {
      id: 1,
      date: new Date(2021, 7, 6, 21, 43),
      nameAndSurnameOfPatient: 'Darko Stojaković',
      text: 'Veoma dobra bolnica s ljubaznim osobljem.',
      isPublished: false
    },
    {
      id: 2,
      date: new Date(2020, 11, 30, 13, 15),
      nameAndSurnameOfPatient: 'Milica Urošević',
      text: 'Stručni lekari koji uspostavljaju prave dijagnoze.',
      isPublished: true
    },
    {
      id: 3,
      date: new Date(2021, 2, 25, 7, 55),
      nameAndSurnameOfPatient: 'Bojan Bjelica',
      text: 'Dugo čekanje na uslugu, nisam baš zadovoljan.',
      isPublished: false
    }
  ];
