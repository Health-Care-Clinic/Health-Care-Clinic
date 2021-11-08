export interface IFeedback {
    id: number;
    date: Date;
    text: string;
    isAnonymous: boolean;
    identity: string;
    canBePublished :boolean;
    isPublished: boolean;
  }
