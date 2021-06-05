import { state } from "@angular/animations";
import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Person } from "../entities/person";
import { appState } from "../store/state";

export const getAllContactsFeature = createFeatureSelector<appState>('contacts');
export const getSelectedPersonFeature = createFeatureSelector<appState>('selectedPerson');

export const getContactsSlice = (state: appState) => {
    return {
      contacts:state.contacts
    };
};

export const getSelectedPersonSlice = (state: appState) => {
  return  {
    selectedPerson:state.selectedPerson
  };
};

export const getAllContacts=createSelector(getAllContactsFeature,getContactsSlice);
export const getSelectedPerson=createSelector(getSelectedPersonFeature,getSelectedPersonSlice);