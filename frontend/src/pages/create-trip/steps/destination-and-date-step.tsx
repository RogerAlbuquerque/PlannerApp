import { ArrowRight, Calendar, MapPin, Settings2, X } from "lucide-react";
import { Button } from "../../../components/buttons";
import { useState } from "react";
import { DateRange, DayPicker } from "react-day-picker";
import 'react-day-picker/dist/style.css'
import { format } from "date-fns";


interface DestinationAndDateStepProps {
    isGuestsInputOpen: boolean;
    closeGuestsInput: () => void;
    openGuestsInput: () => void;
    eventStartAndEndDates: DateRange | undefined;
    setDestination: (destination: string) => void;
    setEventStartAndEndDates: (dates: DateRange | undefined) => void;
}

export function DestinationAndDateStep({
    closeGuestsInput,
    isGuestsInputOpen,
    openGuestsInput,
    setDestination,
    eventStartAndEndDates,
    setEventStartAndEndDates
}: DestinationAndDateStepProps) {
    const [isDatePickerOpen, setIsDatePickerOpen] = useState(false)


    function openDatePicker() {
        setIsDatePickerOpen(true);
    }

    function closeDatePicker() {
        setIsDatePickerOpen(false);
    }

    const displayedDate = eventStartAndEndDates && eventStartAndEndDates.from && eventStartAndEndDates.to
        ? format(eventStartAndEndDates.from, "d' de 'LLL").concat(' até ').concat(format(eventStartAndEndDates.to, "d' de 'LLL"))
        : null

    return (
        <div className="h-16 bg-zinc-900 px-4 rounded-xl flex items-center shadow-shape gap-3">
            <div className="flex items-center gap-2 flex-1">
                <MapPin className="size-5 text-zinc-400" />
                <input
                    disabled={isGuestsInputOpen}
                    type="text"
                    placeholder="Where are you going?" 
                    className="bg-transparent text-lg placeholder-zinc-400 outline-none flex-1"
                    onChange={event => setDestination(event.target.value)}
                />
            </div>

            <button disabled={isGuestsInputOpen} onClick={openDatePicker} className="flex items-center gap-2">
                <Calendar className="size-5 text-zinc-400" />
                <span className="text-lg text-zinc-400 w-40 flex-1">
                    {displayedDate || 'When?'}
                </span>
            </button>

            {isDatePickerOpen && (
                <div className="fixed inset-0 bg-black/60 flex items-center justify-center">
                    <div className="rounded-xl py-5 px-6 shadow-shape bg-zinc-900 space-y-5">
                        <div className="space-y-2">
                            <div className="flex items-center justify-between">
                                <h2 className="font-lg font-semibold">Select date</h2>
                                <button>
                                    <X className="size-5 text-zinc-400" onClick={closeDatePicker} />
                                </button>
                            </div>
                        </div>

                        <DayPicker mode="range" selected={eventStartAndEndDates} onSelect={setEventStartAndEndDates} />
                    </div>
                </div>
            )}


            <div className="w-px h-6 bg-zinc-800" />

            {isGuestsInputOpen ? (
                <Button onClick={closeGuestsInput} variant="secondary">
                    Change location/date
                    <Settings2 className="size-5" />
                </Button>) : (

                <Button onClick={openGuestsInput}>
                    Continue
                    <ArrowRight className="size-5" />
                </Button>
            )}
        </div>
    );
}