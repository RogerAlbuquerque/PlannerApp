import { Plus, User, X } from "lucide-react";
import { FormEvent } from "react";
import { Button } from "../../components/buttons";

interface ConfirmTripModalProps {
    closeConfirmTripModal: () => void
    createTrip: (event: FormEvent<HTMLFormElement>) => void
    setOwnerName: (name: string) => void
    setOwnerEmail: (email: string) => void
}

export function ConfirmTripModal({
    closeConfirmTripModal,
    createTrip,
    setOwnerName,
    setOwnerEmail
}: ConfirmTripModalProps) {
    return (
        <div className="fixed inset-0 bg-black/60 flex items-center justify-center">
            <div className="w-[640px] rounded-xl py-5 px-6 shadow-shape bg-zinc-900 space-y-5">
                <div className="space-y-2">
                    <div className="flex items-center justify-between">
                        <h2 className="font-lg font-semibold">Confirm trip creation</h2>
                        <button>
                            <X className="size-5 text-zinc-400" onClick={closeConfirmTripModal} />
                        </button>
                    </div>

                    <p className="text-sm text-zinc-400">
                        To complete the creation of the trip to <span className="font-semibold text-zinc-100">Florianópolis, Brazil</span> on the dates of <span className="font-semibold text-zinc-100">August 16 to 27, 2024</span> fill in your details below:
                    </p>
                </div>


                <form onSubmit={createTrip} className="space-y-3">
                    <div className="h-14 px-4 bg-zinc-950 border border-zinc-800 rounded-lg flex items-center gap-2">
                        <User className="text-zinc-400 size-5" />
                        <input
                            type="text"
                            name="name"
                            placeholder="Your fullname"
                            className="bg-transparent text-lg placeholder-zinc-400 outline-none flex-1"
                            onChange={event => setOwnerName(event.target.value)}
                        />
                    </div>

                    <div className="h-14 px-4 bg-zinc-950 border border-zinc-800 rounded-lg flex items-center gap-2">
                        <User className="text-zinc-400 size-5" />
                        <input
                            type="email"
                            name="email"
                            placeholder="Your email"
                            className="bg-transparent text-lg placeholder-zinc-400 outline-none flex-1"
                            onChange={event => setOwnerEmail(event.target.value)}
                        />
                    </div>

                    <Button type="submit" size="full">
                        Confirm trip creation
                    </Button>
                </form>
            </div>
        </div>
    );
}