import { FormEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { InviteGuestsModal } from "./invite-guests-modal";
import { ConfirmTripModal } from "./confirm-trip-modal";
import { DestinationAndDateStep } from "./steps/destination-and-date-step";
import { InviteGuestsStep } from "./steps/invite-guests-step";
import { DateRange } from "react-day-picker";
import { api } from "../../lib/axios";

export function CreateTripPage() {
    const navigate = useNavigate();

    const [isGuestsInputOpen, setIsGuestsInputOpen] = useState(false);
    const [isGuestsModalOpen, setIsGuestsModalOpen] = useState(false);
    const [isConfirmTripModalOpen, setIsConfirmTripModalOpen] = useState(false);
    const [emailsToInvite, setEmailsToInvite] = useState([
        'roger@gmail.com'
    ]);

    const [destination, setDestination] = useState('')
    const [ownerName, setOwnerName] = useState('')
    const [ownerEmail, setOwnerEmail] = useState('')
    const [eventStartAndEndDates, setEventStartAndEndDates] = useState<DateRange | undefined>()

    function openGuestsInput() {
        setIsGuestsInputOpen(true)
    }

    function closeGuestsInput() {
        setIsGuestsInputOpen(false)
    }

    function openGuestsModal() {
        setIsGuestsModalOpen(true)
    }

    function closeGuestsModal() {
        setIsGuestsModalOpen(false)
    }

    function openConfirmTripModal() {
        setIsConfirmTripModalOpen(true)
    }

    function closeConfirmTripModal() {
        setIsConfirmTripModalOpen(false)
    }


    function addNewEmailToInvite(event: FormEvent<HTMLFormElement>) {
        event.preventDefault()

        const data = new FormData(event.currentTarget)
        const email = data.get('email')?.toString()

        if (!email) {
            return
        }

        if (emailsToInvite.includes(email)) {
            return
        }

        setEmailsToInvite([
            ...emailsToInvite,
            email
        ])

        event.currentTarget.reset()
    }

    function removeEmailFromInvites(emailToRemove: string) {
        const newEmailList = emailsToInvite.filter(email => email !== emailToRemove)

        setEmailsToInvite(newEmailList)
    }


    async function createTrip(event: FormEvent<HTMLFormElement>) {
        event.preventDefault()
    
        console.log("TA CHEGANDO AQUI?")
    
   
    
       
    
        if (!ownerName) {
          return
        }
    
        console.log("TA CHEGANDO AQUI? 222222")
        const response = await api.post('/trips', {
          name: ownerName,
          startDate: eventStartAndEndDates!.from,
          endDate: eventStartAndEndDates!.to,
          
        })
    
        console.log("TA CHEGANDO AQUI? 3333333333")
        const { tripId } = response.data
    

        console.log("TA CHEGANDO AQUI? 444444444")
        navigate(`/trips/${tripId}`)
      }

    return (
        <div className="h-screen flex items-center justify-center bg-pattern bg-no-repeat bg-center">
            <div className="max-w-3xl w-full px-6 text-center space-y-10">
                <div className="flex flex-col items-center gap-3">
                    <img src="/logo.svg" alt="Planner Logo" />
                    <p className="text-zinc-300 text-lg">
                        Invite your friends and plan your next trip!
                    </p>
                </div>

                <div className="space-y-4">
                    <DestinationAndDateStep
                        closeGuestsInput={closeGuestsInput}
                        isGuestsInputOpen={isGuestsInputOpen}
                        openGuestsInput={openGuestsInput}
                        setDestination={setDestination}
                        setEventStartAndEndDates={setEventStartAndEndDates}
                        eventStartAndEndDates={eventStartAndEndDates}
                    />

                    {isGuestsInputOpen
                        &&
                        <InviteGuestsStep
                            emailsToInvite={emailsToInvite}
                            openConfirmTripModal={openConfirmTripModal}
                            openGuestsModal={openGuestsModal}
                        />
                    }

                    <p className="text-sm text-zinc-500">
                        By planning your trip through the Planner, you automatically agree <br />
                        to ours <a className="text-zinc-300 underline" href="#">terms of use </a> and <a className="text-zinc-300 underline" href="#">privacy policies
                        </a>
                    </p>
                </div>

                {
                    isGuestsModalOpen
                    &&
                    <InviteGuestsModal
                        emailsToInvite={emailsToInvite}
                        addNewEmailToInvite={addNewEmailToInvite}
                        closeGuestsModal={closeGuestsModal}
                        removeEmailFromInvites={removeEmailFromInvites}
                    />
                }

                {isConfirmTripModalOpen && (
                    <ConfirmTripModal
                        closeConfirmTripModal={closeConfirmTripModal}
                        createTrip={createTrip}
                        setOwnerName={setOwnerName}
                        setOwnerEmail={setOwnerEmail}
                    />
                )}
            </div>
        </div>
    );
}

