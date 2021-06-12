import { state } from "@angular/animations";
import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Contact } from "../entities/Contact";
import { appState } from "../store/state";

export const getAllContactsFeature = createFeatureSelector<appState>('contacts');
export const getSelectedContactFeature = createFeatureSelector<appState>('selectedContact');

export const getContactsSlice = (state: appState) => {
    return state.contacts;
};

export const getSelectedContactSlice = (state: appState) => {
  return state.selectedContact;
};

export const getAllContacts=createSelector(getAllContactsFeature,getContactsSlice);
export const getSelectedContact=createSelector(getSelectedContactFeature,getSelectedContactSlice);