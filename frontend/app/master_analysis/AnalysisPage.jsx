import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import React from 'react'

const AnalysisPage = () => {
  return (
    <section className='p-5 bg-gray-200 min-h-screen font-sans'>
        <div className='pt-4 text-3xl font-bold font-sans text-neutral-700'>Master Analysis</div>
        <h2 className='text-gray-500'>Manage analysis method data</h2>
        <div className='max-w-7xl mx-auto bg-white rounded-lg shadow-md p-6 mt-4'>
                {/* Page show & search */}
                <div className='flex justify-between'>
                    <div className=''>
                        <span className="text-sm px-2">Show</span>
                        <select className="border border-gray-300 rounded-md p-1 text-sm">
                            <option>10</option>
                            <option>25</option>
                            <option>50</option>
                        </select>
                    </div>
                    <div className='flex gap-3 items-center'>
                        <span className='text-md'>Search:</span>
                        <Input/>
                        <Button className="bg-green-600 text-white">add</Button>
                    </div>
                </div>
                
                {/* Table Data */}
                <div>

                </div>
                {/* Pagination */}
                <div>
                    <div></div>
                    <div></div>
                </div>
            </div>
    </section>
  )
}

export default AnalysisPage